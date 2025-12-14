package com.grigorijtomczuk.dbuser.data.net

import com.grigorijtomczuk.dbuser.data.net.model.GetManufacturersResponse
import retrofit2.Response
import retrofit2.http.GET

interface ApiService {
    @GET("getallmanufacturers?format=json")
    suspend fun getAllManufacturers(): Response<GetManufacturersResponse>
}