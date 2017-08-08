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
            ConsumersListGrid.DataBound += (s, ev) =>
            {
                if(ConsumersListGrid.HeaderRow != null)
                    ConsumersListGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            };            
        }

        public IQueryable<ConsumerDTO> GetConsumers()
        {
            var consumers = ConsumerService.GetAll().AsQueryable();
            return consumers;
        }

        protected void DeleteConsumer_Command(object sender, CommandEventArgs e)
        {
            var rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            var row = ConsumersListGrid.Rows[rowIndex];
            var consumerId = int.Parse(row.Cells[0].Text);

            ConsumerService.Delete(consumerId);

            ConsumersListGrid.DataBind();
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
            if (Page.IsValid)
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
                ConsumersListGrid.DataBind();
                gridUpdatePanel.Update();
            }            
        }

        protected void DeteOfBirth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var value = args.Value;
            var isValid = DateTime.TryParseExact(value, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            args.IsValid = isValid;
        }
    }
}