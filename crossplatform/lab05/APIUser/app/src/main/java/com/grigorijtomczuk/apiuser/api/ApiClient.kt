package com.grigorijtomczuk.apiuser.api

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object ApiClient {
    private const val BASE_URL = "https://vpic.nhtsa.dot.gov/api/"

    val instance: NhtsaApiService by lazy {
        val retrofit = Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(GsonConverterFactory.create())
            .build()
        retrofit.create(NhtsaApiService::class.java)
    }
}