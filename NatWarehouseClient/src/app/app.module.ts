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
import { MatTableModule, MatSortHeader, MatSortModule, MatInputModule, MatOptionModule, MatSelectModule, MatTabsModule, MatCardModule } from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { StockElementEditorComponent } from './stock-element-editor/stock-element-editor.component';


const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'parts', component: PartsComponent },
  { path: 'statistics', component: StatisticsComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StockElementsComponent,
    StockElementEditorComponent,
    PartsComponent,
    StatisticsComponent,
    StockElementEditorComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    MatSortModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    MatTabsModule,
    MatCardModule,
    BrowserAnimationsModule
  ],
  providers: [
    WarehouseApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
