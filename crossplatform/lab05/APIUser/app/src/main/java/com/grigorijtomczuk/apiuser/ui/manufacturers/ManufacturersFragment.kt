package com.grigorijtomczuk.apiuser.ui.manufacturers

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import com.grigorijtomczuk.apiuser.databinding.FragmentManufacturersBinding
import com.grigorijtomczuk.apiuser.viewmodel.ManufacturersViewModel

class ManufacturersFragment : Fragment() {

    private var _binding: FragmentManufacturersBinding? = null
    private val binding get() = _binding!!

    private lateinit var viewModel: ManufacturersViewModel
    private lateinit var manufacturersAdapter: ManufacturersAdapter

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentManufacturersBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        viewModel = ViewModelProvider(this).get(ManufacturersViewModel::class.java)

        setupRecyclerView()

        viewModel.manufacturers.observe(viewLifecycleOwner) {
            manufacturersAdapter.updateData(it)
        }

        viewModel.isLoading.observe(viewLifecycleOwner) { isLoading ->
            binding.progressBar.visibility = if (isLoading) View.VISIBLE else View.GONE
        }

        viewModel.error.observe(viewLifecycleOwner) { error ->
            Toast.makeText(context, error, Toast.LENGTH_LONG).show()
        }

        viewModel.fetchManufacturers()
    }

    private fun setupRecyclerView() {
        manufacturersAdapter = ManufacturersAdapter(emptyList())
        binding.manufacturersRecyclerView.apply {
            adapter = manufacturersAdapter
            layoutManager = LinearLayoutManager(context)
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}