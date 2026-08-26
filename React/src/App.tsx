import './App.css';
import 'devextreme/dist/css/dx.material.blue.light.compact.css';
import { TabPanel, Item } from 'devextreme-react/tab-panel';
import DataGridLocal from './components/data-grid-local';
import DataGridRemote from './components/data-grid-remote';

function App(): JSX.Element {
  return (
    <div className="main">
      <TabPanel deferRendering={false}>
        <Item title="Local Data" component={DataGridLocal} />
        <Item title="Remote Data" component={DataGridRemote} />
      </TabPanel>
    </div>
  );
}

export default App;
