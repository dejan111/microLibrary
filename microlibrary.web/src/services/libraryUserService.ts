import http from "../http-common";
import { LibraryUser } from "../definitions/definitions";

const getAll = () => {
    return http.get<Array<LibraryUser>>("libraryUser")
};

const get = (id: any) => {
    return http.get<LibraryUser>(`/libraryUser/${id}`);
  };
  
  const create = (data: LibraryUser) => {
    return http.post<LibraryUser>("/LibraryUser/", data);
  };
  
  const update = (data: LibraryUser) => {
    return http.put<any>(`/libraryUser`, data);
  };
  
  const remove = (id: any) => {
    return http.delete<any>(`/libraryUser/${id}`);
  };
  
  const findByLastName = (lastName: string) => {
    return http.get<Array<LibraryUser>>(`/libraryUser?title=${lastName}`);
  };
  
  const LibraryUserService = {
    getAll,
    get,
    create,
    update,
    remove,
    findByLastName,
  };
  
  export default LibraryUserService;