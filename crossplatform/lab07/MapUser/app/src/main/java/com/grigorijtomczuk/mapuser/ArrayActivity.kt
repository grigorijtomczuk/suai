package com.grigorijtomczuk.mapuser

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.grigorijtomczuk.mapuser.databinding.ActivityArrayBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import kotlin.random.Random
import kotlin.system.measureTimeMillis

class ArrayActivity : AppCompatActivity() {

    private lateinit var binding: ActivityArrayBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityArrayBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnProcessArray.setOnClickListener {
            processArray()
        }
    }

    private fun processArray() {
        binding.tvResults.text = "Вычисление..."
        binding.btnProcessArray.isEnabled = false

        CoroutineScope(Dispatchers.Default).launch {
            val sb = StringBuilder()
            val size = 100_000

            val time = measureTimeMillis {
                // 1. Исходный массив
                val originalArray = IntArray(size) { Random.nextInt(0, 1000) }
                appendInfo(sb, "Исходный массив", originalArray)

                // 2. Промежуточный 1: Фильтрация (только четные)
                // Используем filter (возвращает List)
                val filteredList = originalArray.filter { it % 2 == 0 }
                appendInfo(sb, "Промежуточный (filter: четные)", filteredList)

                // 3. Промежуточный 2: Преобразование (возведение в квадрат)
                val mappedList = filteredList.map { it * it }
                appendInfo(sb, "Промежуточный (map: квадрат)", mappedList)

                // 4. Итоговый: Сортировка (по убыванию)
                val sortedList = mappedList.sortedDescending()
                appendInfo(sb, "Итоговый (sortedDescending)", sortedList)
            }

            withContext(Dispatchers.Main) {
                sb.append("\n\nОбщее время выполнения: $time мс")
                binding.tvResults.text = sb.toString()
                binding.btnProcessArray.isEnabled = true
            }
        }
    }

    private fun appendInfo(sb: StringBuilder, label: String, list: List<Int>) {
        sb.append("\n--- $label ---\n")
        sb.append("Размер: ${list.size}\n")
        sb.append("Первые 10 элементов: ${list.take(10).joinToString(", ")}\n")
    }

    private fun appendInfo(sb: StringBuilder, label: String, array: IntArray) {
        sb.append("\n--- $label ---\n")
        sb.append("Размер: ${array.size}\n")
        sb.append("Первые 10 элементов: ${array.take(10).joinToString(", ")}\n")
    }
}
