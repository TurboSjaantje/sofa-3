using System.Reflection;
using System.Runtime.InteropServices;

namespace deel1
{
    public class Order(int orderNr, bool isStudentOrder)
    {
        private int _orderNr = orderNr;
        private readonly bool _isStudentOrder = isStudentOrder;
        private List<MovieTicket> _movieTickets = [];

        public void AddSeatReservation(MovieTicket ticket)
        {
            throw new NotImplementedException();
        }

        public double CalculatePrice()
        {
            var price = 0.0;
            var ticketsAmount = _movieTickets.Count;

            Dictionary<MovieTicket, bool> ticketHasToBePaid = [];

            if (_isStudentOrder)
            {
                // Create list with free second ticket for students
                var hasToBePaid = false;
                foreach (var ticket in _movieTickets)
                {
                    if (hasToBePaid) ticketHasToBePaid.Add(ticket, true);
                    else ticketHasToBePaid.Add(ticket, false);
                    hasToBePaid = !hasToBePaid;
                }
            }
            else
            {
                // Create list with free second ticket for normal person if that ticket falls on discount day
                var hasToBePaid = false;
                foreach (var ticket in _movieTickets)
                {
                    if (hasToBePaid) ticketHasToBePaid.Add(ticket, true);
                    else if (!hasToBePaid && ticket.IsNonStudentDiscountDay()) ticketHasToBePaid.Add(ticket, false);
                    else ticketHasToBePaid.Add(ticket, true);
                    hasToBePaid = !hasToBePaid;
                }
            }


            if (_isStudentOrder)
            {
                // Add premium for better seat for the tickets that have to be paid
                price += 2 * ticketHasToBePaid.Where(t => t.Value == true && t.Key.IsPremiumticket()).Count();
                // Add normal price for the tickets that have to be paid
                price += ticketHasToBePaid.Where(t => t.Value == true).Sum(t => t.Key.GetPrice());
            }
            else
            {
                // Add premium for better seat for the tickets that have to be paid 
                price += 3 * ticketHasToBePaid.Where(t => t.Value == true && t.Key.IsPremiumticket()).Count();
                // Add normal price for the tickets that have to be paid
                price += ticketHasToBePaid.Where(t => t.Value == true).Sum(t => t.Key.GetPrice());
            }

            // Bussiness rule: Add discount for non-student order of >= than 6 tickets
            if (ticketsAmount >= 6 && !_isStudentOrder) price *= 0.90;

            return price;
        }

        public void ExportJson(TicketExportFormat exportFormat)
        {
            if (exportFormat == TicketFormat.JSON)
            {
                FileWrit
            }
            else
            {

            }
        }

        public int GetOrderNr { get { return _orderNr; } }
    }
}