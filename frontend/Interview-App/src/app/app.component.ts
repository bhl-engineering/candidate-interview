import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  @ViewChild('toolbar') toolbar!: ElementRef;
  title = 'Interview-App';

  ngAfterViewChecked() {
    setTimeout(() => {
      this.toolbar.nativeElement.style.minHeight = 100;
    }, 50);
  }
}
