import { Component, ChangeDetectionStrategy } from '@angular/core';
import { DxTabPanelModule } from 'devextreme-angular/ui/tab-panel';
import { DataGridLocalComponent } from './components/data-grid-local/data-grid-local.component';
import { DataGridRemoteComponent } from './components/data-grid-remote/data-grid-remote.component';

@Component({
  selector: 'app-root',
  imports: [DxTabPanelModule, DataGridLocalComponent, DataGridRemoteComponent],
  templateUrl: './app.component.html',
  changeDetection: ChangeDetectionStrategy.Eager,
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {}
