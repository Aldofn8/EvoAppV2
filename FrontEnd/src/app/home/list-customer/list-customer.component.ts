import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { CustomerService, Customer } from '../../services/customer.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
  styleUrls: ['./list-customer.component.css'],
  providers: [MessageService, ConfirmationService, ]
})
export class ListCustomerComponent implements OnInit{
  listCustomer!: any;
  customers!: Customer[];
  customer!: Customer;
  submitted: boolean = false;
  customerDialog: boolean = false;
  myForm!: FormGroup;

  constructor(private customerService: CustomerService, fb: FormBuilder) {}
  
  ngOnInit(){
    this.getCustomers();
    this.myForm = new FormGroup({
      name: new FormControl(),
      surname: new FormControl(),
      dni: new FormControl(),
      birthDate: new FormControl(),
      phone: new FormControl(),
      email: new FormControl(),
      password: new FormControl(),
      checkedState: new FormControl(),
      checkedVerify: new FormControl()
  });
  }

  
  getCustomers() {
    this.customerService.getCustomer()
    .subscribe((listCustomer) =>
      {
        this.listCustomer = listCustomer;
      })
  }

   openNew() {
       this.submitted = false;
       this.customerDialog = true;
   }

   hideDialog() {
       this.customerDialog = false;
       this.submitted = false;
   }


   saveProduct(customer: {cName: string, cSurname: string, cDni: number, cBirthDate: Date, cPhone: number, cEmail: string, cPassword: string, cState: boolean, cVerify: boolean }) {
       
       console.log(customer);
        this.customerService.addCustomer(customer)
        .subscribe((res) =>{
          console.log(res);
        })
   }
}
