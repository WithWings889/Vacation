import { Injectable } from '@angular/core';
import { Transport } from './transport.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root' 
})
export class TransportService {
  formData  : Transport;
  list : Transport[];
  readonly rootURL ="http://localhost:44335/api"

  constructor(private http : HttpClient) { }

  postTransport(formData : Transport){
   return this.http.post(this.rootURL+'/Transports',formData);
  }

  refreshList(){
    
    this.http.get(this.rootURL+'/Transports')
    .toPromise().then(res => this.list = res as Transport[]);
  }

  putTransport(formData : Transport){
    return this.http.put(this.rootURL+'/Transports/'+formData.TransportID,formData);
     
   }

   deleteTransport(id : number){
    return this.http.delete(this.rootURL+'/Transports/'+id);
   }
}

