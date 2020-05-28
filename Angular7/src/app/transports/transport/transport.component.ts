import { Component, OnInit } from '@angular/core';
import { TransportService } from 'src/app/shared/transport.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-transport',
  templateUrl: './transport.component.html',
  styleUrls: ['./transport.component.css']
})
export class TransportComponent implements OnInit {

  constructor(public service: TransportService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      TransportID: null,
      Name: ''
    }
  }


  onSubmit(form: NgForm) {
    if (form.value.TransportID == null)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postTransport(form.value).subscribe(res => {
      this.toastr.success('Inserted successfully', 'EMP. Register');
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  updateRecord(form: NgForm) {
    this.service.putTransport(form.value).subscribe(res => {
      this.toastr.info('Updated successfully', 'EMP. Register');
      this.resetForm(form);
      this.service.refreshList();
    });

  }
}
