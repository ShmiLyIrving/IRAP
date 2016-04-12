using System.Drawing;

namespace IRAP.Components.WorkFlow
{
    public interface IPaintItem
    {
        Color ItemColor { get; set; }
        Font ItemFont { get; set; }
        Image ItemImage { get; }
        Point ItemLocate { get; set; }
        string ItemName { get; set; }
        ItemStatus ItemStatus { get; set; }

        void DrawSelf(Graphics graphics, Pen pen = null);
    }
}