import { Component, OnInit } from '@angular/core';
import { TransportService } from 'src/app/shared/transport.service';
import { Transport } from 'src/app/shared/transport.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-transport-list',
  templateUrl: './transport-list.component.html',
  styleUrls: ['./transport-list.component.css']
})
export class TransportListComponent implements OnInit {

  constructor(public service: TransportService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(emp: Transport) {
    this.service.formData = Object.assign({}, emp);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteTransport(id).subscribe(res => {
        this.service.refreshList();
        this.toastr.warning('Deleted successfully', 'EMP. Register');
      });
    }
  }

}
