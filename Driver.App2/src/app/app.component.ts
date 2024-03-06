import { Component } from '@angular/core';
import { Driver } from './models/driver';
import { DriverService } from './services/driver.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Driver.App2';
  drivers:Driver[]=[];

  constructor(private driverService: DriverService){}

  ngOnInit(): void {
    this.driverService.getDriver().subscribe((result: Driver[]) => {
      this.drivers = result;});
    }
}