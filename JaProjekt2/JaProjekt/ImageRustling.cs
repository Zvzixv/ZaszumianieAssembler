using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JaProjekt
{
    class ImageRustling
    {
     
              
        public static void ImageRustl(Bitmap source, int threads, bool isCS, bool isAsm)
        {
            Bitmap newBitmap = new Bitmap(source);
            int stopien = 2;
            int beginColumn = 0;
            int endColumn = 0;

            int modulo = source.Width % threads;  //reszta z dzielenia tzn ile trzeba rozdac
            int baseColumns = source.Width / threads; ///po ile na wątek
            List<ThreadWithState> threadList = new List<ThreadWithState>();
            PararelBitmap pb = new PararelBitmap(newBitmap, isAsm);
            for (int i=0; i< threads; i++)
            {
                endColumn = beginColumn + baseColumns;  //bloczek kolumn
                if(modulo>0)  //rozdawanie reszty
                {
                    endColumn++;
                    modulo--;
                }
                var tws = new ThreadWithState(pb, stopien, beginColumn, endColumn, isAsm);
                Thread t = new Thread(new ThreadStart(tws.Zaszum)); 
                threadList.Add(tws);
               // t.Start();

                beginColumn = endColumn;
            }
            for (int i = 0; i < threads; i++)
            {
                Thread t = new Thread(new ThreadStart(threadList[i].Zaszum));
                t.Start();
            }


            while (!IsFinish(threadList));

            pb.Close();
            newBitmap.Save("wynik.bmp");
            string message = "Finished!";
           
            MessageBox.Show( message, "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


           
/*
            typedef void(_stdcall * MyProc1)(int a, int b, RGBApixel * *c, RGBApixel * *d, int stopien, int skok);
            HINSTANCE dllHandle = NULL;
            dllHandle = LoadLibrary(L"JAAsm.dll");
            MyProc1 procedura = (MyProc1)GetProcAddress(dllHandle, "MyProc1");
*/
            //t.Start();


            //t.Join();

        }

        private static bool IsFinish(List<ThreadWithState> threadList)
        {
            foreach(ThreadWithState thread in threadList)
            {
                if(!thread.Finish)
                {
                    return false;
                }
            }
            return true;
        }

        

        
    }
}
