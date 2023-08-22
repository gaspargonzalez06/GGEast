using Micros.PosCore.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEatsApp
{
    internal class ApplicationFactory : IExtensibilityAssemblyFactory
    {

        // Se crea el estado para el funcionamiento de la app
        public ExtensibilityAssemblyBase Create(IExecutionContext context)
        {
            return new Application(context);
        }

        /// <summary>
        /// Para cerrar la ventana 
        /// </summary>
        /// <param name="app"></param>
        public void Destroy(ExtensibilityAssemblyBase app)
        {
            app.Destroy();
        }
    }
}

