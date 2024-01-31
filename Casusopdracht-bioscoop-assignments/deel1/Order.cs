namespace deel1
{
    public class Order(int orderNr, bool isStudentOrder)
    {
        private int _orderNr = orderNr;
        private readonly bool _isStudentOrder = isStudentOrder;
        private List<MovieTicket> movieTickets = [];

        public void AddSeatReservation(MovieTicket ticket)
        {
            throw new NotImplementedException();
        }

        public double CalculatePrice()
        {
            throw new NotImplementedException();
        }

        public void Export(TicketExportFormat exportFormat)
        {
            throw new NotImplementedException();
        }
        public int OrderNr { get { return _orderNr; } }
    }
}