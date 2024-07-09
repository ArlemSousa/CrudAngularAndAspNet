import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PessoasService } from './pessoas.service';
import { PessoasComponent } from './Components/pessoas/pessoas.component';


@NgModule({
  declarations: [
    AppComponent,
    PessoasComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,

  ],
  providers: [HttpClientModule, PessoasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
