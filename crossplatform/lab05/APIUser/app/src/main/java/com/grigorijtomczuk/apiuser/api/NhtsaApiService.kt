package com.grigorijtomczuk.apiuser.api

import retrofit2.Response
import retrofit2.http.GET
import retrofit2.http.Query

interface NhtsaApiService {
    @GET("vehicles/GetAllManufacturers")
    suspend fun getManufacturers(
        @Query("format") format: String = "json",
        @Query("VehicleType") vehicleType: String = "motorcycle"
    ): Response<ManufacturerResponse>
}