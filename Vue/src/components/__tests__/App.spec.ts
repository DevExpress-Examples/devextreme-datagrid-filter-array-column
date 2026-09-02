import { describe, it, expect } from 'vitest';
import { mount } from '@vue/test-utils';
import App from '../../App.vue';

describe('App', () => {
  it('renders local and remote data tabs', () => {
    const wrapper = mount(App);
    expect(wrapper.text()).toContain('Local Data');
    expect(wrapper.text()).toContain('Remote Data');
  });
});
