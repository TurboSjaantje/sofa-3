using deel1;

var movieTicket = new MovieTicket(1, 1, true, new MovieScreening(DateTime.Now, 10, new Movie("test")));
var order = new Order(1, true);

order.AddSeatReservation(movieTicket);

order.ExportJson(TicketExportFormat.JSON); 