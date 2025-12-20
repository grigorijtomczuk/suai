package com.grigorijtomczuk.mapuser

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.grigorijtomczuk.mapuser.databinding.ActivityArrayBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import kotlin.math.pow
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
            val size = 150_000

            // Генерация массива
            val originalArray = IntArray(size) { Random.nextInt(0, 1000) }

            appendInfo(sb, "Исходный массив", originalArray)

            var sortedListOptimized: List<Int> = emptyList()
            val timeOptimized = measureTimeMillis {
                val filteredList = originalArray.filter { it % 2 == 0 }
                val mappedList = filteredList.map { it * it }
                sortedListOptimized = mappedList.sortedDescending() // O(N * log N)
            }

            appendInfo(sb, "Результат (оптим.)", sortedListOptimized)
            sb.append("Время выполнения: $timeOptimized мс\n")

            // Используем уменьшенный массив, иначе Bubble Sort на 150к зависнет
            val unoptimizedSize = 5_000

            val smallArray = originalArray.copyOfRange(0, unoptimizedSize)
            var sortedListUnoptimized = ArrayList<Int>()

            val timeUnoptimized = measureTimeMillis {
                val filtered = ArrayList<Int>()
                for (i in smallArray) {
                    if (i % 2 == 0) filtered.add(i)
                }

                val mapped = ArrayList<Int>()
                for (i in filtered) {
                    mapped.add(i * i)
                }

                // bubble sort O(N^2)
                for (i in 0 until mapped.size - 1) {
                    for (j in 0 until mapped.size - i - 1) {
                        if (mapped[j] < mapped[j + 1]) {
                            val temp = mapped[j]
                            mapped[j] = mapped[j + 1]
                            mapped[j + 1] = temp
                        }
                    }
                }
                sortedListUnoptimized = mapped
            }

            appendInfo(sb, "Результат (неоптим.)", sortedListUnoptimized)
            sb.append("Время выполнения: $timeUnoptimized мс\n")

            if (unoptimizedSize < size) {
                val projectedTime =
                    (timeUnoptimized * (size / unoptimizedSize).toDouble().pow(2))
                sb.append("Примерное время для $size элементов: ${projectedTime / 1000} сек\n")
            }

            withContext(Dispatchers.Main) {
                binding.tvResults.text = sb.toString()
                binding.btnProcessArray.isEnabled = true
            }
        }
    }

    private fun appendInfo(sb: StringBuilder, label: String, list: List<Int>) {
        sb.append("\n> $label\n")
        sb.append("Размер: ${list.size}\n")
        sb.append("Первые 10 элементов: ${list.take(10).joinToString(", ")}\n")
    }

    private fun appendInfo(sb: StringBuilder, label: String, array: IntArray) {
        sb.append("\n> $label\n")
        sb.append("Размер: ${array.size}\n")
        sb.append("Первые 10 элементов: ${array.take(10).joinToString(", ")}\n")
    }
}
