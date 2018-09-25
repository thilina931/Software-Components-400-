using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace TrueMarbleData
{
    //LaB practical05
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]


    internal class TMDataControllerImpl : ITMDataController
    {
        TMDataControllerImpl()
        {
            System.Console.WriteLine("Client Connected !!!");
        }

        ~TMDataControllerImpl()
        {
            System.Console.WriteLine("Client Disconnected !!!");
        }

        public int GetNumTilesAcross(int zoom)
        {

            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetNumTiles(zoom, out numTilesX, out numTilesY);

            return (numTilesY * numTilesX);

        }

        public int GetNumTilesDown(int zoom)
        {
            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetTileSize(out numTilesX, out numTilesY);

            return numTilesY;

        }

        public int GetTileHeight()
        {
            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetTileSize(out numTilesX, out numTilesY);

            return numTilesX;
        }

        public int GetTileWidth()
        {
            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetTileSize(out numTilesX, out numTilesY);

            return numTilesY;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /* Activity 02 tread serilization lab05         */
        public byte[] LoadTile(int zoom, int x, int y)
        {
            int sizeX ;

            int sizeY ;

            int jpgSize;

            TMDLLWrapper.GetTileSize(out sizeX, out sizeY);

            int charBuffferSize = (sizeX * sizeY * 3);

            byte[] imageData = new byte[charBuffferSize];

           

         

            TMDLLWrapper.GetTileImageAsRawJPG(zoom,x,y, imageData, charBuffferSize, out jpgSize);

            return imageData;

        }

    }
}