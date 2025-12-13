package com.grigorijtomczuk.apiuser.api

import retrofit2.Response
import retrofit2.http.GET
import retrofit2.http.Header
import retrofit2.http.Query

interface ApiService {
    @GET("motorcycles")
    suspend fun getMotorcycles(
        @Header("X-Api-Key") apiKey: String = "4hmnPRfAo9Cmst+a/XuQLA==jFZfmwEbiPVbBv1u",
        @Query("make") make: String?,
        @Query("model") model: String?,
//        @Query("year") year: Int? = 2022,
    ): Response<List<Motorcycle>>
}