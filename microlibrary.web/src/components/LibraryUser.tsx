import React, { useState, useEffect, ChangeEvent } from "react";
import { useParams } from 'react-router-dom';

import LibraryUserService from "../services/libraryUserService";
import { LibraryUser as LibraryUserDef } from "../definitions/definitions";

const LibraryUser = () => {
    const initialLibraryUserState = {
        id: null,
        libraryId: null,
        firstName: "",
        lastName: "",
        oib: "",
        postalCode: "",
        address: "",
        city: "",
        dateOfBirth: null,
        active: false,
        libraryUserContacts: []
    };

    const { id } = useParams();

    const [currentLibraryUser, setCurrentLibraryUser] = useState<LibraryUserDef>(initialLibraryUserState);
    const [message, setMessage] = useState<string>("");

    const getLibraryUser = (id: string | undefined) => {
        LibraryUserService.get(id)
        .then((response: any) => {
            setCurrentLibraryUser(response.data);
            console.log(response.data);
        })
        .catch((e: Error) => {
            console.log(e);
        });
    };

    useEffect(() => {
        getLibraryUser(id);
    }, [id]);

    const handleInputChange = (event: ChangeEvent) => {
        const { name } = event.target as HTMLInputElement;
        var value = (event.target as HTMLInputElement).value;
        setCurrentLibraryUser({ ...currentLibraryUser, [name]: value });
    };

    const updateActive = (status: boolean) => {
        var data = {
        // libraryId: currentLibraryUser.libraryId,
        id: currentLibraryUser.id,
        libraryId: 2,
        firstName: currentLibraryUser.firstName,
        lastName: currentLibraryUser.lastName,
        oib: currentLibraryUser.oib,
        postalCode: currentLibraryUser.postalCode,
        address: currentLibraryUser.address,
        city: currentLibraryUser.city,
        dateOfBirth: currentLibraryUser.dateOfBirth,
        active: true,
        };

        LibraryUserService.update(data)
        .then((response: any) => {
            console.log(response.data);
            setCurrentLibraryUser({ ...currentLibraryUser });
            setMessage("The status was updated successfully!");
        })
        .catch((e: Error) => {
            console.log(e);
        });
    };

    const updateLibraryUser = () => {
        LibraryUserService.update(currentLibraryUser)
        .then((response: any) => {
            console.log(response.data);
            setMessage("The tutorial was updated successfully!");
        })
        .catch((e: Error) => {
            console.log(e);
        });
    };

    const deleteLibraryUser = () => {
        LibraryUserService.remove(currentLibraryUser.id)
        .then((response: any) => {
            console.log(response.data);
        })
        .catch((e: Error) => {
            console.log(e);
        });
    };

    return (
    <div>
      {currentLibraryUser ? (
        <div className="edit-form">
          <h4>Library user</h4>
          <form>
            <div className="form-group">
              <label htmlFor="firstName">First name</label>
              <input
                type="text"
                className="form-control"
                id="firstName"
                name="firstName"
                value={currentLibraryUser.firstName}
                onChange={handleInputChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="lastName">Last name</label>
              <input
                type="text"
                className="form-control"
                id="lastName"
                name="lastName"
                value={currentLibraryUser.lastName}
                onChange={handleInputChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="postalCode">Postal code</label>
              <input
                type="text"
                className="form-control"
                id="postalCode"
                name="postalCode"
                value={currentLibraryUser.postalCode}
                onChange={handleInputChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="address">Address</label>
              <input
                type="text"
                className="form-control"
                id="address"
                name="address"
                value={currentLibraryUser.address}
                onChange={handleInputChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="city">City</label>
              <input
                type="text"
                className="form-control"
                id="city"
                name="city"
                value={currentLibraryUser.city}
                onChange={handleInputChange}
              />
            </div>

          <button onClick={deleteLibraryUser}>
            Delete
          </button>

          <button
            type="submit"
            onClick={updateLibraryUser}
          >
            Update
          </button>
          <p>{message}</p>
            </form>
        </div>
      ) : (
        <div>
          <br />
          <p>Please click on a library user...</p>
        </div>
      )
    }
    </div>
    );
};

export default LibraryUser;