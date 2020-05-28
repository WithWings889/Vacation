import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { TransportsComponent } from './transports/transports.component';
import { TransportComponent } from './transports/transport/transport.component';
import { TransportListComponent } from './transports/transport-list/transport-list.component';
import { TransportService } from './shared/transport.service';

@NgModule({
  declarations: [
    AppComponent,
    TransportsComponent,
    TransportComponent,
    TransportListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [TransportService],
  bootstrap: [AppComponent]
})
export class AppModule { }