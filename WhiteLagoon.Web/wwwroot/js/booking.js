var dataTable;

$(document).ready(function () {
  const urlParams = new URLSearchParams(window.location.search);
  const status = urlParams.get('status');
  loadDataTable(status);
});

function loadDataTable(status) {
  dataTable = $("#tblBookings").DataTable({
    ajax: {
      url: "/booking/getall?status="+status,
    },
    columns: [
      { data: "bookingId", autoWidth: true },
      { data: "name", autoWidth: true },
      { data: "email", autoWidth: true },
      { data: "phone", autoWidth: true },
      { data: "status", autoWidth: true },
      { data: "checkInDate", autoWidth: true },
      { data: "nights", autowidth: true },
      { data: "totalCost", autoWidth: true },
      {
        data: 'id',
        "render": function (data) {
          return `<div class="w=75 btn-group">
            <a href="/booking/bookingDetails?bookingId=${data}" class="btn btn-outline-warning mx-2">
              <i class="bi bi-pencil-square"></i> Details
            </a>
          </div>`
        }
      }
    ],
  });
}
