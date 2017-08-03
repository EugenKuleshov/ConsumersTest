using System;
using System.Collections.Generic;
using System.Web.UI;
using ConsumersTest.ConsumerServiceReference;
using System.Linq;

namespace ConsumersTest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsumersList.HeaderRow.TableSection = System.Web.UI.WebControls.TableRowSection.TableHeader;
        }

        public IQueryable<Consumer> GetConsumers()
        {
            var client = new ConsumerServiceClient("BasicHttpsBinding_IConsumerService");
            var consumers = client.GetAll().AsQueryable();
            return consumers;
        }
    }
}