using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_ConstructionSite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConstructionWorker worker = new ConstructionWorker();
            worker.BuildStructure();
            worker.InstallPlumbing();
            worker.InstallElectrical();

        }
    }
    public interface IConstruction
    {
        void BuildStructure();
        void InstallPlumbing();
        void InstallElectrical();
    }
    public class ConstructionWorker : IConstruction
    {
        public void BuildStructure()
        {
            // Code to build a structure
        }

        public void InstallPlumbing()
        {
            // Code to install plumbing
        }

        public void InstallElectrical()
        {
            // Code to install electrical
        }
    }

}
