
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploedFile } from '../models/uploed-file';

@Injectable({
  providedIn: 'root'
})
export class ImegesService {

  constructor(private client: HttpClient) { }

  // Function to upload an image and get back a URL
  uploadImage(file: File): Observable<UploedFile> {
    const formData = new FormData(); // Create FormData object
    formData.append("file", file); // Append the file to FormData object

    // Send POST request to server with FormData
    return this.client.post<UploedFile>('https://localhost:7191/api/File', formData);
  }
}
