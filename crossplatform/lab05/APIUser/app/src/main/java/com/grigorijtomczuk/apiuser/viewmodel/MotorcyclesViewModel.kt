package com.grigorijtomczuk.apiuser.viewmodel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.grigorijtomczuk.apiuser.api.ApiClient
import com.grigorijtomczuk.apiuser.api.Motorcycle
import kotlinx.coroutines.launch

class MotorcyclesViewModel : ViewModel() {

    private val _motorcycles = MutableLiveData<List<Motorcycle>>()
    val motorcycles: LiveData<List<Motorcycle>> = _motorcycles

    private val _isLoading = MutableLiveData<Boolean>()
    val isLoading: LiveData<Boolean> = _isLoading

    private val _error = MutableLiveData<String>()
    val error: LiveData<String> = _error

    fun fetchMotorcycles(make: String, model: String) {
        viewModelScope.launch {
            _isLoading.value = true
            try {
                val response = ApiClient.instance.getMotorcycles(make = make, model = model)
                if (response.isSuccessful && response.body() != null) {
                    _motorcycles.value = response.body()!!
                } else {
                    _error.value = "Ошибка запроса"
                }
            } catch (e: Exception) {
                if (e is java.net.SocketTimeoutException || e is java.net.UnknownHostException)
                    _error.value = "Отсутствует интернет-соединение"
                else
                    _error.value = "Возникла ошибка: ${e.message}"
            }
            _isLoading.value = false
        }
    }
}