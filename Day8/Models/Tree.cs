using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Models
{
    public class Tree
    {
        public bool IsEdge { get;  }
        public bool Visible { get; }

        public int Height { get; }
        public int LeftView { get; }
        public int RightView { get; }
        public int TopView { get;  }
        public int BottomView { get; }

        public Tree(int height, bool isEdge = false, bool visible = false, int left = 0, int right = 0, int top = 0, int bottom = 0)
        {
            Height = height;
            Visible = visible;
            IsEdge = isEdge;
            LeftView = left;
            RightView = right;
            TopView = top;
            BottomView = bottom;
        }

        public Tree IsAnEdge()
        {
            return new Tree(Height, isEdge: true, Visible);
        }

        public Tree IsVisible()
        {
            return new Tree(Height, IsEdge, visible: true);
        }

        public Tree WithLeftView(int amount)
        {
            return new Tree(Height, IsEdge, Visible, amount, RightView, TopView, BottomView);
        }

        public Tree WithRightView(int amount)
        {
            return new Tree(Height, IsEdge, Visible, LeftView, amount, TopView, BottomView);
        }

        public Tree WithTopView(int amount)
        {
            return new Tree(Height, IsEdge, Visible, LeftView, RightView, amount, BottomView);
        }

        public Tree WithBottomView(int amount)
        {
            return new Tree(Height, IsEdge, Visible, LeftView, RightView, TopView, amount);
        }
    }
}
