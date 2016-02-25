using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
//using MyServiceProxy;

namespace MVC_ClientWCF.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await ChamarServico();

            return View();
        }

        public ActionResult Contact()
        {
            Chamador();

            return View();
        }


        private static async Task<RetornoContract> ChamarServico()
        {
            using (HistoricoFluxoServiceClient client = new HistoricoFluxoServiceClient())
            {
                return await client.IncluirHistoricoFluxoTaskAsync("autorizacao", new HistoricoAutorizacaoContract()
                {
                    Acao = "teste",
                    Criado = DateTime.Now,
                    Historico = "historico",
                    IDItemCriado = 1,
                    ListaItemOrigem = "origem"
                }, false);
            }
        }


        private Task<RetornoContract> Chamador()
        {
            return Task.Run(new Func<Task<RetornoContract>>(async () =>
            {
                using (HistoricoFluxoServiceClient client = new HistoricoFluxoServiceClient())
                {
                    return await client.IncluirHistoricoFluxoTaskAsync("autorizacao", new HistoricoAutorizacaoContract()
                    {
                        Acao = "teste",
                        Criado = DateTime.Now,
                        Historico = "historico",
                        IDItemCriado = 1,
                        ListaItemOrigem = "origem"
                    }, false);
                }
            }));
        }


        private static async void ChamadorAsync()
        {
            using (HistoricoFluxoServiceClient client = new HistoricoFluxoServiceClient())
            {
                await Task.Factory.StartNew(() =>
                {
                    client.IncluirHistoricoFluxoTaskAsync("autorizacao", new HistoricoAutorizacaoContract()
                    {
                        Acao = "teste",
                        Criado = DateTime.Now,
                        Historico = "historico",
                        IDItemCriado = 1,
                        ListaItemOrigem = "origem"
                    }, false);
                });
            }
        }
    }
}