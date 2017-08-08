using System;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using ConsumersTest.Infrastructure.Extension;
using System.Globalization;
using ConsumersTest.Services.Interfaces;
using ConsumersTest.Services.DTO;

namespace ConsumersTest
{
    public partial class _Default : Page
    {
        public IConsumerService ConsumerService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ConsumersList.DataBound += (s, ev) =>
            {
                if(ConsumersList.HeaderRow != null)
                    ConsumersList.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        public IQueryable<ConsumerDTO> GetConsumers()
        {
            var consumers = ConsumerService.GetAll().AsQueryable();
            return consumers;
        }

        protected void TryDeleteConsumer_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            var gridRow = (GridViewRow)button.NamingContainer;
            var consumerId = int.Parse(gridRow.Cells[0].Text);
            var consumerName = gridRow.Cells[1].Text;

            ConsumerIdField.Value = consumerId.ToString();
            deleteModalBody.Text = $"Are you sure you want to delete {consumerName}";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "delete-modal", "$('#delete-modal').modal();", true);
            deleteModalUpdatePanel.Update();
        }

        protected void DeleteConsumer_Click(object sender, EventArgs e)
        {
            var consumerId = int.Parse(ConsumerIdField.Value);
            ConsumerService.Delete(consumerId);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "delete-modal", "$('#delete-modal').modal('hide');", true);
            ConsumersList.DataBind();
            gridUpdatePanel.Update();
        }

        protected void AddConsumer_Click(object sender, EventArgs e)
        {
            var textBoxes = addModalUpdatePanel.Controls
                .All()
                .OfType<TextBox>();

            foreach (var textBox in textBoxes)            
                textBox.Text = string.Empty;

            addModalUpdatePanel.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "add-modal", "$('#add-modal').modal();", true);
        }

        protected void SubmitConsumer_Click(object sender, EventArgs e)
        {
            var consumer = new ConsumerDTO()
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                Email = EmailBox.Text,
                DateOfBirth = DateTime.ParseExact(DateOfBirthBox.Text, "M/d/yyyy", CultureInfo.InvariantCulture)
            };
            ConsumerService.Add(consumer);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "add-modal", "$('#add-modal').modal('hide');", true);
            ConsumersList.DataBind();
            gridUpdatePanel.Update();
        }
    }
}