import React, { useState, useEffect, ChangeEvent } from "react";
import LibraryUserService from "../services/libraryUserService";
import {LibraryUser} from '../definitions/definitions';
import { Link } from "react-router-dom";

const LibraryUsers = () => {
  const [libraryUsers, setLibraryUsers] = useState<Array<LibraryUser>>([]);
  const [currentLibraryUser, setCurrentLibraryUser] = useState<LibraryUser | null>(null);
  const [currentIndex, setCurrentIndex] = useState<number>(-1);
  const [searchLastName, setSearchLastName] = useState<string>("");

  useEffect(() => {
    retrieveLibraryUsers();
  }, []);

  const onChangeSearchLastName = (e: ChangeEvent<HTMLInputElement>) => {
    const searchLastName = e.target.value;
    setSearchLastName(searchLastName);
  };

  const retrieveLibraryUsers = () => {
    LibraryUserService.getAll()
      .then((response: any) => {
        setLibraryUsers(response.data);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };

  const setActiveLibraryUser = (libraryUser: LibraryUser, index: number) => {
    setCurrentLibraryUser(libraryUser);
    setCurrentIndex(index);
  };

  const findByLastName = () => {
    LibraryUserService.findByLastName(searchLastName)
      .then((response: any) => {
        setLibraryUsers(response.data);
        setCurrentLibraryUser(null);
        setCurrentIndex(-1);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };

  return (
    <div className="list row">
    <div className="col-md-8">
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Search by last name"
          value={searchLastName}
          onChange={onChangeSearchLastName}
        />
        <div className="input-group-append">
          <button
            className="btn btn-outline-secondary"
            type="button"
            onClick={findByLastName}
          >
            Search
          </button>
        </div>
      </div>
    </div>
    <div className="col-md-6">
      <h4>Library users</h4>

      <ul className="list-group">
        {libraryUsers &&
          libraryUsers.map((libraryUser, index) => (
            <li
              className={
                "list-group-item " + (index === currentIndex ? "active" : "")
              }
              onClick={() => setActiveLibraryUser(libraryUser, index)}
              key={index}
            >
              {libraryUser.firstName} {libraryUser.lastName}
            </li>
          ))}
      </ul>
    </div>
    <div className="col-md-6">
      {currentLibraryUser ? (
        <div>
          <h4>{currentLibraryUser.firstName} {currentLibraryUser.lastName}</h4>
          <div>
            <label>
              <strong>Address:</strong>
            </label>{" "}
            {currentLibraryUser.address}, {currentLibraryUser.city}, {currentLibraryUser.postalCode}
          </div>
          <div>
            <label>
              <strong>Oib:</strong>
            </label>{" "}
            {currentLibraryUser.oib}
          </div>
          <div>
            <label>
              <strong>Date of birth:</strong>
            </label>{" "}
            {currentLibraryUser.dateOfBirth}
          </div>

          <Link to={"/libraryUser/" + currentLibraryUser.id} >
            Edit
          </Link>
        </div>
      ) : (
        <div>
          <br />
          <p>Please click on a library user...</p>
        </div>
      )}
    </div>
  </div>
  )
};

export default LibraryUsers;