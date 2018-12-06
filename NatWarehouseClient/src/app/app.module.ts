import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { StockElementsComponent } from './stock-elements/stock-elements.component';
import { PartsComponent } from './parts/parts.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { RouterModule, Routes } from '@angular/router';
import { WarehouseApiService } from './warehouse-api.service';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material';


const appRoutes: Routes = [
  { path: '', component: HomeComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StockElementsComponent,
    PartsComponent,
    StatisticsComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    AppRoutingModule,
    HttpClientModule,
    MatTableModule
  ],
  providers: [
    WarehouseApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
