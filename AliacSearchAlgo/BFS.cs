using System;
using System.Collections;
using AISearchSample;
using System.Windows.Forms;

namespace AliacSearchAlgo
{
    class BFS
    {
        ArrayList nodes;
        Fringes fringe;
        bool start = false;

        public BFS(ArrayList nodes)
        {
            this.nodes = nodes;
            fringe = new Fringe();
        }

        public void setStart(Node n)
        {
            n.Start = true;
        }

        public void setGoal(Node n)
        {
            n.Goal = true;
        }

        public Node search()
        {
            Node explored = null;

            if (!start)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (((Node)nodes[i]).Start == true)
                    {
                        fringe.add((Node)nodes[i], null);
                    }
                }
                start = true;
            }

            Node explorer = null;
            ArrayList temp;

            while ((explorer = fringe.remove()) != null)
            {
                if (explorer.Goal == true)
                {
                    explorer.Expanded = true;
                    MessageBox.Show("Found: " + explorer.Name);
                    explored = explorer;
                    break;
                }

                temp = explorer.getNeighbor();
                foreach (Node neighbor in temp)
                {
                    if (!neighbor.Expanded)
                    {
                        fringe.add(neighbor, explorer);
                    }
                }
                explorer.Expanded = true;
                explored = explorer;
            }

            return explored;
        }
    }
}
