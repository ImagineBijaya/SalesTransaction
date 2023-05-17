import { NgModule } from '@angular/core';
import { MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar'
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {MatInputModule} from '@angular/material/input';
const MaterialComponents =[
  MatButtonModule,
  MatToolbarModule,
  MatCardModule,
  MatTableModule,
  MatCheckboxModule,
  MatInputModule
]

@NgModule({
  imports: [MaterialComponents

  ],
  exports:[MaterialComponents]
})
export class MaterialModule { }
