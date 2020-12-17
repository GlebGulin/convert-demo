import logo from './logo.svg';
import './App.css';
import ConvertContainer from './Components/ConvertContainer';
import { Route,  BrowserRouter } from 'react-router-dom';

const App = (props) => {
  debugger;
  return (
    // <BrowserRouter>
    <div className="wrapper">
     
      
      <Route path="/" render={() => <ConvertContainer />} />

    </div>
    // </BrowserRouter>
  );
}
export default App;
