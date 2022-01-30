import React, { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import './App.css';

import LibraryUsers from "./components/LibraryUsers";
import AddLibraryUser from "./components/AddLibraryUser";
import LibraryUser from "./components/LibraryUser";

const App= () => {
  return(
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/libraryUsers" className="navbar-brand">
          MicroLibrary
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/add"} className="nav-link">
              Add
            </Link>
          </li>
        </div>
      </nav>

      <div className="container mt-3">
        <Routes>
          <Route path='/' element={ <LibraryUsers /> } />
          <Route path='/libraryUsers' element={ <LibraryUsers /> } />
          <Route path='/libraryUser/:id' element={ <LibraryUser /> } />
          <Route path='/add' element={ <AddLibraryUser /> } />
        </Routes>
      </div>
    </div>
  );
}

export default App;