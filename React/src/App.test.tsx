import { render, screen } from '@testing-library/react';
import App from './App.tsx';

test('renders local and remote data tabs', () => {
  render(<App />);
  expect(screen.getByText('Local Data')).toBeInTheDocument();
  expect(screen.getByText('Remote Data')).toBeInTheDocument();
});
