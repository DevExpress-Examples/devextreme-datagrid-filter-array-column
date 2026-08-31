import { createApp } from 'vue';
import config from 'devextreme/core/config';
import App from './App.vue';
import { licenseKey } from './devextreme-license';

import './assets/main.css';

config({ licenseKey });

createApp(App).mount('#app');
