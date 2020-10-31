import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { HttpService } from '../../../@core/services/http.service';

@Component({
  selector: 'ngx-setting',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.scss']
})
export class SettingComponent implements OnInit {
  settingfrm: FormGroup;
  submitted = false;
  cred_value: any = []
  value = ['JSON', 'Number', 'Text'];
  editBtn : boolean = false;
  showEditBtn :boolean= true;

 
  constructor(private formBuilder: FormBuilder,
    protected httpService: HttpService,
    protected router: Router,
    private toastrService: NbToastrService) {
    this.getSettingRecord(localStorage.getItem('ActiveOrganizationID'),localStorage.getItem('personId'));
     }

  ngOnInit(): void {
    this.settingfrm = this.formBuilder.group({
      smtpConfiguration: [''],
      timeZone: [''],
      storageLocation: ['']
 
    }); 
  }
 
  
  getSettingRecord(org_id,user_id){
    this.httpService.get(`Organizations/${org_id}/OrganizationSettings`).subscribe((data:any) =>
    {
     
      this.settingfrm.patchValue(data.items[0])
      this.settingfrm.disable();
    })
  }




   
  // convenience getter for easy access to form fields
  get f() { return this.settingfrm.controls; }


  onSubmit() {
    let orgId= localStorage.getItem('ActiveOrganizationID')
    let personId = localStorage.getItem('personId')
    this.submitted = true;
    if (this.settingfrm.invalid) {
      return;
    }
    this.httpService.put(`Organizations/${orgId}/OrganizationSettings/${personId}`,this.settingfrm.value).subscribe(
      (data) => {
        this.toastrService.success('Setting Update  Successfully!','Success');
        // this.router.navigate(['pages/agents/list'])
      });
  }


  showUpdateBtn(){
    this.showEditBtn = false;
    this.editBtn = true 
    this.settingfrm.enable();
  }

  onReset() {
    this.submitted = false;
    this.settingfrm.reset();
  }


}
