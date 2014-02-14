using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OpenTK_NeHe_Solution
{
    static class Program
    {
        /// <summary>  
        /// The main entry point for the application.  
        /// </summary>  
        [STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.  
            // We request 30 UpdateFrame events per second, and unlimited  
            // RenderFrame events (as fast as the computer can handle).  
            using (NeHe1 game = new NeHe1())
            {
                game.Run(60, 60);
            }
        }
    }
}