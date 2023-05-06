import logo from './logo.svg';
import './App.css';
import GameComponent from './Components/Home/GameComponent';
import NavbarComponent from './Components/Nav/Navbar';
import "bootstrap/dist/css/bootstrap.min.css";
import {Route, Routes} from "react-router-dom";
import Register from './Components/Auth/Register';
import Login from './Components/Auth/Login';
import UsersListComponent from './Components/UsersList/UsersListComponent';
import RankingComponent from './Components/Rankings/Rankings'
import Addgame from './Components/Adding/AddGame';
import AddCourt from './Components/Adding/AddCourt';
function App() {
  return (
    <div className="App">
      <NavbarComponent></NavbarComponent>
      <div className="container">
       <Routes>
        <Route path="/" element={<GameComponent></GameComponent>}/>
        <Route path="Rankings" element={<RankingComponent></RankingComponent>}/>
        <Route path="Users" element={<UsersListComponent></UsersListComponent>}/>
        <Route path="Register" element={<Register></Register>}/>
        <Route path="Login" element={<Login></Login>}/>
        <Route path="AddGame" element={<Addgame></Addgame>}/>
        <Route path="AddCourt" element={<AddCourt></AddCourt>}/>
       </Routes> 
      </div>    
    </div>
  );
}

export default App;
