import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Blog } from './blog';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  blogFormData: Blog = new Blog();
  readonly baseURL = 'https://localhost:44368/api/blog';
  constructor(private _http: HttpClient) { }

  postBlog(){
    return this._http.post(this.baseURL,this.blogFormData);
  }

  putBlog(){
    return this._http.put(this.baseURL,this.blogFormData);
  }

  deleteBlog(id: number){
    return this._http.delete(`${this.baseURL}/${id}`);
  }
  list:{id:number, blogTitle: string, content: string}[]=[];

  getBlog(){
    this._http.get(this.baseURL).subscribe(
      Response => {
        this.list = Object.values(Response);
      console.log("res");
      console.log(this.list[0]);
      return this.list[0];
      });
  }

  id: number = 1;
  onSetIdForSpecificBlog(id: number){
    this.id = id;
  }
}
