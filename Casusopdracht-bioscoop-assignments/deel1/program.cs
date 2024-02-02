using deel1;

var movieTicket1 = new MovieTicket(1, 1, false, new MovieScreening(DateTime.Now, 10, new Movie("test")));
var movieTicket2 = new MovieTicket(1, 1, true, new MovieScreening(DateTime.Now.AddDays(-2), 10, new Movie("test")));
var movieTicket3 = new MovieTicket(1, 1, true, new MovieScreening(DateTime.Now, 10, new Movie("test")));
var movieTicket4 = new MovieTicket(1, 1, false, new MovieScreening(DateTime.Now, 10, new Movie("test")));

var order1 = new Order(1, true);
var order2 = new Order(2, false);

order1.AddSeatReservation(movieTicket1);
order1.AddSeatReservation(movieTicket2);
//order1.AddSeatReservation(movieTicket3);
//order1.AddSeatReservation(movieTicket4);

order2.AddSeatReservation(movieTicket1);
order2.AddSeatReservation(movieTicket2);
order2.AddSeatReservation(movieTicket3);
order2.AddSeatReservation(movieTicket4);

order1.Export(TicketExportFormat.JSON); 
order2.Export(TicketExportFormat.JSON);

Console.WriteLine($"Order 1 {order1.CalculatePrice().ToString("F2")}");
Console.WriteLine($"Order 2 {order2.CalculatePrice().ToString("F2")}");


