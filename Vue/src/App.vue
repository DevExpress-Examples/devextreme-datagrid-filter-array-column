<script setup lang="ts">
import 'devextreme/dist/css/dx.material.blue.light.compact.css';
import DxTabPanel, { DxItem } from 'devextreme-vue/tab-panel';
import DataGridLocal from './components/DataGridLocal.vue';
import DataGridRemote from './components/DataGridRemote.vue';
</script>

<template>
  <div class="main">
    <DxTabPanel :defer-rendering="false">
      <DxItem title="Local Data">
        <DataGridLocal/>
      </DxItem>
      <DxItem title="Remote Data">
        <DataGridRemote/>
      </DxItem>
    </DxTabPanel>
  </div>
</template>
