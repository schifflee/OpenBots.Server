import { NgModule } from '@angular/core';
import { SettingRoutingModule } from './setting-routing.module';
import { SettingComponent } from './setting/setting.component';
import { SharedModule } from '../../@core/shared/shared.module';
 
@NgModule({
  declarations: [SettingComponent],
  imports: [
 
    SettingRoutingModule,
    SharedModule
  ]
})
export class SettingModule { }
