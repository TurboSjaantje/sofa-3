using System.Text.Json;

namespace deel1
{
    public class Order(int orderNr, bool isStudentOrder)
    {
        public int OrderNr { get; } = orderNr;
        public bool IsStudentOrder { get; } = isStudentOrder;
        public List<MovieTicket> MovieTickets { get; } = [];

        public void AddSeatReservation(MovieTicket ticket)
        {
            MovieTickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            Dictionary<MovieTicket, bool> ticketList;

            //Bussiness rule: Add potential for free tickets
            if (IsStudentOrder) ticketList = GetTicketListStudent();
            else ticketList = GetTicketListNonStudent();

            //Bussiness rule: Get the base price for tickets that have to be paid
            double price = (double) GetBasePrice(ticketList);

            //Bussiness rule: Apply premium for tickets with better seats
            price += (double) GetPremium(ticketList);

            // Bussiness rule: Add discount for non-student order of >= than 6 tickets
            if (MovieTickets.Count >= 6 && !IsStudentOrder) price *= (double) 0.90;

        
            return price;
        }

        public Dictionary<MovieTicket, bool> GetTicketListStudent()
        {
            Dictionary<MovieTicket, bool> ticketHasToBePaid = [];

            // Create list with free second ticket for students
            var hasToBePaid = false;
            foreach (var ticket in MovieTickets)
            {
                if (hasToBePaid) ticketHasToBePaid.Add(ticket, true);
                else ticketHasToBePaid.Add(ticket, false);
                hasToBePaid = !hasToBePaid;
            }

            return ticketHasToBePaid;
        }

        public Dictionary<MovieTicket, bool> GetTicketListNonStudent()
        {
            Dictionary<MovieTicket, bool> ticketHasToBePaid = [];

            var hasToBePaid = false;
            foreach (var ticket in MovieTickets)
            {
                if (hasToBePaid) ticketHasToBePaid.Add(ticket, true);
                else if (!hasToBePaid && ticket.IsNonStudentDiscountDay()) ticketHasToBePaid.Add(ticket, false);
                else ticketHasToBePaid.Add(ticket, true);
                hasToBePaid = !hasToBePaid;
            }

            return ticketHasToBePaid;
        }

        public decimal GetPremium(Dictionary<MovieTicket, bool> ticketList)
        {
            var premium = IsStudentOrder ? 2.0 : 3.0;

            // Add premium for better seat for the tickets that have to be paid
            var result = (decimal) (premium *  ticketList.Where(t => t.Value == true && t.Key.IsPremium).Count());
            return result;
        }

        public static double GetBasePrice(Dictionary<MovieTicket, bool> ticketList)
        {
            // Add normal price for the tickets that have to be paid
            return ticketList.Where(t => t.Value == true).Sum(t => t.Key.GetPrice());
        }

        public void ExportJson(TicketExportFormat exportFormat)
        {
            string outputFolder = "file-write-outputs";

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string fileName = $"output_{DateTime.Now:yyyyMMddhhmmss}";
            string filePath = Path.Combine(outputFolder, $"{fileName}.{(exportFormat == TicketExportFormat.JSON ? "json" : "txt")}");

            WriteToFile(filePath);
        }

        private void WriteToFile(string filePath)
        {
            string jsonData = JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }
    }
}