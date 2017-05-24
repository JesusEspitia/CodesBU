using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownMonitoring
{
    public class Warehouse
    {
        protected ConnectWarehouse conWare;
        protected List<string> machines = new List<string>();
        protected List<string> partNumbers = new List<string>();
        protected List<string> sets = new List<string>();
        protected string resulthtml = "";
        protected string headText="";
        private int dayscount = 0;

        public Warehouse()
        {
            
        }

        protected void getParts(List<string> machine)
        {
            partNumbers.Clear();
            List<string> parttemp = new List<string>();
            bool cont = true;
            foreach(string s in machine)
            {
                parttemp.Clear();
                conWare.fillList(parttemp, string.Format("select part_number from Machines where id_machine='{0}'", s));
                foreach(string p in parttemp)
                {
                    foreach(string t in partNumbers)
                    {
                        if (p == t)
                        {
                            cont = false;
                            break;
                        }
                        else
                        {
                            cont = true;
                        }
                    }
                    if (cont == true)
                    {
                        partNumbers.Add(p);
                    }
                }
            }
        }

        protected void getDays()
        {
            resulthtml = "";
            foreach(string s in partNumbers)
            {
                if (conWare.getValueBool(string.Format("select * from Warehouse where part_number='{0}'", s)) == true)
                {
                    sets.Clear();
                    int demand = 0;
                    int inv = Convert.ToInt32(conWare.getValue(string.Format("select quantity+baffer as disp from Warehouse where part_number='{0}'", s)));
                    conWare.fillList(sets, string.Format("select distinct(setId) from Sets where part_number='{0}'", s));
                    string name = conWare.getValue(string.Format("select description from Component where part_number='{0}'", s));
                    foreach (string t in sets)
                    {
                        demand += request(t, s);
                    }
                    double days = Math.Round(Convert.ToDouble((inv * dayscount) / demand), 2);
                    if (days < 6)
                    {
                        headText = "<h3>Componentes comprometidos:</h3><br>";
                        resulthtml = resulthtml + "Componente: " + s + " / " + name + " disponible en inventario: " + inv + " equivalente a: " + days + " días.<br>";
                    }
                    dayscount = 0;
                }
            }
        }

        private int request(string s,string part)
        {
            int daystemp = 0;
            int a, b, c, d, e, f, g, h, i, j, k, l;
            a = Convert.ToInt32(conWare.getValue(string.Format("select monday from SetsWeek where setId={0}", s)));
            b= Convert.ToInt32(conWare.getValue(string.Format("select tuesday from SetsWeek where setId={0}", s)));
            c= Convert.ToInt32(conWare.getValue(string.Format("select wednesday from SetsWeek where setId={0}", s)));
            d= Convert.ToInt32(conWare.getValue(string.Format("select thursday from SetsWeek where setId={0}", s)));
            e= Convert.ToInt32(conWare.getValue(string.Format("select friday from SetsWeek where setId={0}", s)));
            f= Convert.ToInt32(conWare.getValue(string.Format("select saturday from SetsWeek where setId={0}", s)));
            int qnty = Convert.ToInt32(conWare.getValue(string.Format("select quantity from Sets where setId={0} and part_number='{1}'", s,part)));
            if (a != 0)
            {
                daystemp += 1;
            }
            if (b != 0)
            {
                daystemp += 1;
            }
            if (c != 0)
            {
                daystemp += 1;
            }
            if (d != 0)
            {
                daystemp += 1;
            }
            if (e != 0)
            {
                daystemp += 1;
            }
            if (f != 0)
            {
                daystemp += 1;
            }

            if(daystemp > dayscount)
            {
                dayscount = daystemp;
            }
            return (a*qnty) + (b * qnty) + (c * qnty) + (d * qnty) + (e * qnty) + (f * qnty);
        }
    }
}
