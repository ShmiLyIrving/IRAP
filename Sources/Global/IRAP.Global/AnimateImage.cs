using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace IRAP.Global
{
    /// <summary>
    /// 表示一类带动画功能的图像
    /// </summary>
    public class AnimateImage
    {
        private Image image = null;
        private FrameDimension frameDimension;
        private bool canAnimate = false;
        private int frameCount = 1;
        private int currentFrame = 0;

        /// <summary>
        /// 动画当前帧发生变化时触发
        /// </summary>
        public event EventHandler<EventArgs> OnFrameChanged;

        /// <summary>
        /// 实例化一个 AnimateImage
        /// </summary>
        /// <param name="img">动画图片</param>
        public AnimateImage(Image img)
        {
            image = img;

            lock (image)
            {
                canAnimate = ImageAnimator.CanAnimate(image);
                if (canAnimate)
                {
                    Guid[] guid = image.FrameDimensionsList;
                    frameDimension = new FrameDimension(guid[0]);
                    frameCount = image.GetFrameCount(frameDimension);
                }
            }
        }

        /// <summary>
        /// 图片
        /// </summary>
        public Image Image
        {
            get { return image; }
        }

        /// <summary>
        /// 是否动画
        /// </summary>
        public bool CanAnimate
        {
            get { return canAnimate; }
        }

        /// <summary>
        /// 总帧数
        /// </summary>
        public int FrameCount
        {
            get { return FrameCount; }
        }

        /// <summary>
        /// 播放的当前帧
        /// </summary>
        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            if (canAnimate)
            {
                lock (image)
                {
                    ImageAnimator.Animate(image, new EventHandler(FrameChanged));
                }
            }
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        public void Stop()
        {
            if (canAnimate)
            {
                lock (image)
                {
                    ImageAnimator.StopAnimate(image, new EventHandler(FrameChanged));
                }
            }
        }

        /// <summary>
        /// 重置动画，使之停留在第0帧的位置上
        /// </summary>
        public void Reset()
        {
            if (canAnimate)
            {
                ImageAnimator.StopAnimate(image, new EventHandler(FrameChanged));
                lock (image)
                {
                    image.SelectActiveFrame(frameDimension, 0);
                    currentFrame = 0;
                }
            }
        }

        private void FrameChanged(object sender, EventArgs e)
        {
            currentFrame = currentFrame + 1 >= frameCount ? 0 : currentFrame++;
            lock (image)
            {
                image.SelectActiveFrame(frameDimension, currentFrame);
            }
            if (OnFrameChanged != null)
            {
                OnFrameChanged(image, e);
            }
        }
    }
}
