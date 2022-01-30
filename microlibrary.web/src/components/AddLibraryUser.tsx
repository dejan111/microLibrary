import React, { useState, ChangeEvent } from "react";
import LibraryUserService from "../services/libraryUserService";
import { LibraryUser } from "../definitions/definitions";

const AddLibraryUser = () => {
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

    const [libraryUser, setLibraryUser] = useState<LibraryUser>(initialLibraryUserState);
    const [submitted, setSubmitted] = useState<boolean>(false);

    const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setLibraryUser({ ...libraryUser, [name]: value });
      };

      const saveLibraryUser = () => {
          var data = {
            //   libraryId: libraryUser.libraryId,
            libraryId: 2,
            firstName: libraryUser.firstName,
            lastName: libraryUser.lastName,
            oib: libraryUser.oib,
            postalCode: libraryUser.postalCode,
            address: libraryUser.address,
            city: libraryUser.city,
            dateOfBirth: libraryUser.dateOfBirth ?? new Date(),
            active: libraryUser.active,
            //   libraryUserContacats: libraryUser.libraryUserContacts
          };

          LibraryUserService.create(data)
            .then((response: any) => {
                setLibraryUser({
                    id: response.Data.id,
                    libraryId: response.Data.libraryId,
                    firstName: response.Data.firstName,
                    lastName: response.Data.lastName,
                    oib: response.Data.oib,
                    postalCode: response.Data.postalCode,
                    address: response.Data.address,
                    city: response.Data.city,
                    dateOfBirth: response.Data.dateOfBirth,
                    active: response.Data.active,
                });
                setSubmitted(true);
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
      };

      const newLibraryUser = () => {
          setLibraryUser(initialLibraryUserState);
          setSubmitted(false);
      };

      return (
        <div className="submit-form">
      {submitted ? (
        <div>
          <h4>You submitted successfully!</h4>
          <button className="btn btn-success" onClick={newLibraryUser}>
            Add
          </button>
        </div>
      ) : (
        <div>
          <div className="form-group">
            <label htmlFor="firstName">First name</label>
            <input
              type="text"
              className="form-control"
              id="firstName"
              required
              value={libraryUser.firstName}
              onChange={handleInputChange}
              name="firstName"
            />
          </div>

          <div className="form-group">
            <label htmlFor="lastName">Last name</label>
            <input
              type="text"
              className="form-control"
              id="lastName"
              required
              value={libraryUser.lastName}
              onChange={handleInputChange}
              name="lastName"
            />
          </div>

          <div className="form-group">
            <label htmlFor="oib">Oib</label>
            <input
              type="text"
              className="form-control"
              id="oib"
              required
              value={libraryUser.oib}
              onChange={handleInputChange}
              name="oib"
            />
          </div>

          <div className="form-group">
            <label htmlFor="postalCode">Postal code</label>
            <input
              type="text"
              className="form-control"
              id="postalCode"
              required
              value={libraryUser.postalCode}
              onChange={handleInputChange}
              name="postalCode"
            />
          </div>

          <div className="form-group">
            <label htmlFor="address">Address</label>
            <input
              type="text"
              className="form-control"
              id="address"
              required
              value={libraryUser.address}
              onChange={handleInputChange}
              name="address"
            />
          </div>

          <div className="form-group">
            <label htmlFor="city">City</label>
            <input
              type="text"
              className="form-control"
              id="city"
              required
              value={libraryUser.city}
              onChange={handleInputChange}
              name="city"
            />
          </div>

            {/* TODO - add datepicker */}

          <button onClick={saveLibraryUser} className="btn btn-success">
            Submit
          </button>
        </div>
      )}
    </div>
      );
};

export default AddLibraryUser;